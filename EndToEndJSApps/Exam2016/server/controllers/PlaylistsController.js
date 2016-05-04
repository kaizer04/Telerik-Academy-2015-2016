var playlists = require('../data/playlists'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'playlists';

module.exports = {
    getCreate: function(req, res){
        res.render(CONTROLLER_NAME + '/create', {
            categories: constants.categories
        });
    },
    postCreate: function(req, res){
        var playlist = req.body;
        var user = req.user;
        playlists.create(
            playlist,
            {
                username: user.username
            },
            function(err, playlist){
                if(err){
                    var data = {
                        categories: constants.categories,
                        errorMessage: err
                    };

                    res.render(CONTROLLER_NAME + '/create', data);
                }
                else {
                    res.redirect('details/' + playlist._id);
                }
        })
    },
    //getPopular: function(req, res) {
    //    playlists.popular(function(err, data) {
    //        res.render(CONTROLLER_NAME + '/home', {
    //            data: data
    //        });
    //    });
    //}
    getPlaylistDetails: function (req, res) {
        var playlistId = req.params.id;

        playlists.getPlaylistDetails(playlistId, function (playlist) {
            //var isPartOfPlaylist = isCurrentUserPartOfThisPlaylist(playlist.joinedInUsers, req.user.username);
            res.render(CONTROLLER_NAME + '/details', { playlist: playlist });
        });
    },
};