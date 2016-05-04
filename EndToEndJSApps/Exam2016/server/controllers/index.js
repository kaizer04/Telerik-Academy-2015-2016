var UsersController = require('./UsersController'),
    HomeController = require('./HomeController'),
    PlaylistsController = require('./PlaylistsController');

module.exports = {
    users: UsersController,
    home: HomeController,
    playlists: PlaylistsController
};