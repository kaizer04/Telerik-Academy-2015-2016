var encryption = require('../utilities/encryption');
var users = require('../data/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    getProfileDetails: function (req, res) {
        var user = req.user;

        res.render(CONTROLLER_NAME + '/profile', { user: user })
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;

        if (!(newUserData.username && typeof newUserData.username === 'string' && newUserData.username.length >= 6 && newUserData.username.length <= 20)) {
            req.session.error = 'The username should be between 6 and 20 characters long.';
            res.redirect('/register');
            return;
        }

        if (!(newUserData.password && newUserData.password.length >= 1) && !(newUserData.confirmPassword && newUserData.confirmPassword.length >= 1)) {
            req.session.error = 'The chosen password is invalid!';
            res.redirect('/register');
            return;
        }

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Password does not match the confirm password!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            users.create(newUserData, function(err, user) {
                if (err) {
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()}); // TODO:
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    updateUser: function (req, res) {
        var userId = req.user._id;
        var updatedUserData = req.body;

        users.update(userId, updatedUserData, function (data) {
            res.redirect('/profile');
        })
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    }
};