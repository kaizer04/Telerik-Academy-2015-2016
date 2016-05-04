var playlists = require('../data/playlists'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'playlists';

module.exports = {
    getPopular: function(req, res) {
        playlists.popular(function(err, data) {
            res.render(CONTROLLER_NAME + '/home', {
                data: data
            });
        });
    }
};