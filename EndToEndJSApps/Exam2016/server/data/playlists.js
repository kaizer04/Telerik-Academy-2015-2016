var Playlist = require('mongoose').model('Playlist'),
    constants = require('../common/constants');

var cache = {
    expires: undefined,
    data: undefined
};

module.exports = {
    create: function(playlist, user, callback) {
        if (constants.categories.indexOf(playlist.category) < 0) {
            callback('Invalid category!');
            return;
        }

        playlist.creator = user.username;
        playlist.date = new Date(Date.now());
        playlist.date.setMonth(10); // TODO: fix


        Playlist.create(playlist, callback);
    },
    popular: function(callback) {

        if (cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }
        Playlist.find(
            { limit: 8},
            { sort: { rating: -1 } },
            function (error, playlists) {
            callback(playlists);
        })

        //
        //Playlist
        //    .find({
        //    })
        //    .sort({
        //        rating: 'desc'
        //    })
        //    .limit(8)
        //    .exec(function(err, foundPlaylists) {
        //        if (err) {
        //            callback(err);
        //            return;
        //        }
        //
        //        Playlist.count().exec(function(err, numberOfPlaylists) {
        //            var data = {
        //                events: foundPlaylists,
        //                //currentPage: page,
        //                //pageSize: pageSize,
        //                total: numberOfPlaylists
        //            };
        //
        //            callback(err, data);
        //
        //            cache.data = data;
        //            cache.expires = new Date() + 10;
        //        });
        //    })
    },
    getPlaylistDetails: function (playlistId, callback) {
        Playlist.findOne({ _id: playlistId }, function (error, playlist) {
            callback(playlist);
        })
    },
};