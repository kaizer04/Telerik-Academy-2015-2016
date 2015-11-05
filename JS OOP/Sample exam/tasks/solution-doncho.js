function solve() {
    if (!Array.prototype.find) {
        Array.prototype.find = function(predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.find called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return value;
                }
            }
            return undefined;
        };
    }

    if (!Array.prototype.findIndex) {
        Array.prototype.findIndex = function(predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.findIndex called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return i;
                }
            }
            return -1;
        };
    }

    function isStringValid(str, minLength, maxLength){
        return typeof (str) === 'string' &&
            str.length >= minLength &&
            str.length <= maxLength;
    }

    var player = function(){
        function byNameThenById(pl1, pl2){
            if(pl1.name === pl2.name){
                return pl1.id - pl2.id;
            }

            return pl1.name.localeCompare(pl2.name);
        }

        var player = {
            init: function(name){
                this.name = name;
                this.playlists = [];
                return this;
            },
            get name(){
                return this._name;
            },
            set name(newName){
                if(!isStringValid(newName, 3, 25)){
                    throw {
                        name: 'InvalidPlayerNameError',
                        message: 'InvalidPlayerNameError'
                    }
                }
                this._name = newName;
            },
            addPlaylist: function(playlist){
                if(typeof(playlist.id) === 'undefined' || !playlist.name){
                    throw {
                        name: 'InvalidPlayerPlaylistError',
                        message: 'InvalidPlayerPlaylistError'
                    };
                }
                this.playlists.push(playlist);
                return this;
            },
            getPlaylistById: function(id){
                var i,
                    len;
                for(i = 0, len = this.playlists.length; i < len; i += 1){
                    if(this.playlists[i].id === id){
                        return this.playlists[i];
                    }
                }

                return null;
            },
            removePlaylist: function(arg){
                var id = arg;
                if(typeof(arg) === 'undefined'){
                    throw {
                        name: 'InvalidIdError',
                        message: 'InvalidIdError'
                    };
                }

                if(typeof(arg) !== 'number'){
                    id = arg.id;
                }

                var index = this.playlists.findIndex(function(playlist){
                    return playlist.id === id;
                });

                if(index < 0){
                    throw {
                        name: 'InvalidIdError',
                        message: 'InvalidIdError'
                    }
                }

                this.playlists.splice(index, 1);

                return this;
            },
            listPlaylists: function(page, size){
                if(typeof(page) === 'undefined' || typeof(size) === 'undefined' ||
                    page < 0 || size <= 0 || page * size > this.playlists.length){
                    throw {
                        name: 'InvalidPageSizeError',
                        message: 'InvalidPageSizeError'
                    }
                }

                this.playlists.sort(byNameThenById);
                var from = page * size;
                var countPerPage = (page + 1) * size;

                return this.playlists.slice(from, countPerPage);
            },
            search: function(patern){
                patern = patern.toLowerCase();
                return this.playlists.filter(function(playlist){
                   return playlist.getAllPlayables()
                       .some(function(playable){
                            return playable.title.toLowerCase()
                                .indexOf(patern) >= 0;
                        });
                });
            }
        };

        return player;
    }();

    var playlist = function(){
        var lastId = 0;
        var playlist = {
            init: function(name){
                this.id = lastId += 1;
                this.name = name;
                this.playables = [];
                return this;
            },
            get name(){
                return this._name;
            },
            set name(newName){
                if(!isStringValid(newName, 3, 25)){
                    throw {
                        name: 'InvalidPlayListNameError',
                        message: 'InvalidPlayListNameError'
                    }
                }
                this._name = newName;
            },
            getAllPlayables: function(){
                return this.playables.slice();
            },
            addPlayable: function(playable){
                if(typeof(playable.id) === 'undefined' || !playable.title){
                    throw {
                        name: 'InvalidPlayableError',
                        message: 'InvalidPlayableError'
                    };
                }
                this.playables.push(playable);
                return this;
            },
            getPlayableById: function(id){
                var i,
                    len;
                for(i = 0, len = this.playables.length; i < len; i += 1){
                    if(this.playables[i].id === id){
                        return this.playables[i];
                    }
                }

                return null;
            },
            removePlayable: function(arg){
                var id = arg;
                if(typeof(arg) === 'undefined'){
                    throw {
                        name: 'InvalidIdError',
                        message: 'InvalidIdError'
                    };
                }

                if(typeof(arg) !== 'number'){
                    id = arg.id;
                }

                var index = this.playables.findIndex(function(playable){
                    return playable.id === id;
                });

                if(index < 0){
                    throw {
                        name: 'InvalidIdError',
                        message: 'InvalidIdError'
                    }
                }

                this.playables.splice(index, 1);

                return this;
            },
            listPlayables: function(page, size){
                if(typeof(page) === 'undefined' || typeof(size) === 'undefined' ||
                    page < 0 || size <= 0 || page * size > this.playables.length){
                    throw {
                        name: 'InvalidPageSizeError',
                        message: 'InvalidPageSizeError'
                    }
                }

                this.playables.sort(function(pl1, pl2){
                    if(pl1.title === pl2.title){
                        return pl1.id - pl2.id;
                    }

                    return pl1.title.localeCompare(pl2.title);
                });

                var from = page * size;
                var countPerPage = (page + 1) * size;

                return this.playables.slice(from, countPerPage);
            }
        };

        return playlist;
    }();

    var playable = function(){
        var lastId = 0,
            playable = {
            init: function(title, author){
                //this.id = lastId += 1;
                lastId += 1;
                this.id = lastId;
                this.title = title;
                this.author = author;
                return this;
            },
            get title(){
                return this._title;
            },
            set title(newTitle){
                if(!isStringValid(newTitle, 3, 25)){
                    throw {
                        name: '',
                        message: ''
                    };
                }
                this._title = newTitle;
            },
            get author(){
                return this._author;
            },
            set author(newAuthor){
                if(!isStringValid(newAuthor, 3, 25)){
                    throw {
                        name: 'InvalidAuthorError',
                        message: 'Author must be a string with length between 3 and 25'
                    };
                }
                this._author = newAuthor;
            },
            play: function(){
                return this.id + '. ' + this.title + ' - ' + this.author;
            }
        };

        return playable;
    }();

    var audio = function(parent){
        var audio = Object.create(parent);

        audio.init = function(title, author, length){
            parent.init.call(this, title, author);
            this.length = length;
            return this;
        };

        audio.play = function(){
            return parent.play.call(this) + ' - ' + this.length;
        };

        Object.defineProperty(audio, 'length', {
            get: function(){
                return this._length;
            },
            set: function(newLength){
                newLength = +newLength;
                if(typeof(newLength) !== 'number' || newLength <= 0){
                    throw {
                        name: '',
                        message: ''
                    }
                }
                this._length = newLength;
            }
        });

        return audio;
    }(playable);

    var video = function(parent){
        var video = Object.create(parent);

        video.init = function(title, author, imdbRating){
            parent.init.call(this, title, author);
            this.imdbRating = imdbRating;
            return this;
        };

        video.play = function(){
            return parent.play.call(this) + ' - ' + this.imdbRating;
        };

        Object.defineProperty(video, 'imdbRating', {
            get: function(){
                return this._imdbRating;
            },
            set: function(newImdbRating){
                //if(typeof(newImdbRating) !== 'number' || newImdbRating < 1 || newImdbRating > 5){
                //    throw {
                //        name: '',
                //        message: ''
                //    };
                //}
                //this._imdbRating = newImdbRating;
            }
        });

        return video;
    }(playable);

    var module = {
        getPlayer: function(name){
            return Object.create(player)
                .init(name);
        },
        getPlaylist: function(name){
            return Object.create(playlist)
                .init(name);
        },
        getAudio: function(title, author, length){
            return Object.create(video)
                .init(title, author, length);
        },
        getVideo: function(title, author, imdbRating){
            return Object.create(video)
                .init(title, author, imdbRating);
        }
    };

    return module;
}

var module = solve();
//console.log(module.getVideo('Te sa zeleni', 'Keranov', 5).play());
//var playlist = module.getPlaylist('Rock\'n\'Roll');
////console.log(playlist.getPlayableById(777777));
//console.log(playlist.listPlayables(1, 0));
////for(var i = 1; i < 14; i += 1){
////    playlist.addPlayable(module.getAudio('Te sa zeleni ' + i, 'Keranov ' + i, 3.27 + i % 2));
////}
////playlist.removePlayable(777777);
var player = module.getPlayer('John\'s Player');
//var playable = playlist.getPlayableById(7);
var playlist = module.getPlaylist('The BG');
playlist.addPlayable(module.getAudio('Te sa zeleni', 'Keranov', 3.37))
    .addPlayable(module.getAudio('Te sa cherni', 'Chernio', 45));
//console.log(playable);
////console.log('--------------------');
////console.log(playlist.listPlayables(1, 10));
player.addPlaylist(playlist);
////
var playlist2 = module.getPlaylist('GOsho\' Playlist');
playlist2.addPlayable(module.getAudio('Te sa zeleni', 'Keranov', 3.37));
player.addPlaylist(playlist2);
// console.log(player.listPlaylists(0, 100));
//console.log(player.search('zeleni'));
////
console.log(player.search('cherni'));
//
console.log('***********');
console.log(player.search('te sa'));
//playlist.removePlayable(playable);
//console.log(playlist.listPlayables(0, 10000));
