var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

var requiredMessage = '{PATH} is required';
var defaultAvatar = 'https://ninjageisha.files.wordpress.com/2012/08/ninja-tadaa.jpg';

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, required: requiredMessage, unique: true },
        salt: String,
        hashPass: String,
        firstName: { type: String, required: requiredMessage},
        lastName: { type: String, required: requiredMessage},
        externalProfiles: {
            facebook: { type: String },
            youTube: { type: String }
        },
        email: { type: String, required: requiredMessage},
        avatar: { type: String, default: defaultAvatar },
        rating: { type: Number, default: 0, min: 0 }
    });

    // Validation
    userSchema.path('username').validate(function (value) {
        return value.length >= 6 && value.length <= 20;
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);
};


