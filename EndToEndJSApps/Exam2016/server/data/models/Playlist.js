var mongoose = require('mongoose');

var requiredMessage = '{PATH} is required';

module.exports.init = function() {
    var playlistSchema = mongoose.Schema({
        title: { type: String, required: requiredMessage },
        description: { type: String, required: requiredMessage },
        category: { type: String, required: requiredMessage },
        video: { type: String, required: requiredMessage },
        date: { type: Date, required: requiredMessage, default: function() { return Date.now(); } },
        creator: { type: String, required: requiredMessage },
        isPrivate: { type: Boolean, default: false },
        comments: [{
            username: String,
            content: String,
            rating: { type: Number, default: 0, min: 0 }
        }],
        totalAvgRating: { type: Number, default: 0, min: 0 }
    });

    var Playlist = mongoose.model('Playlist', playlistSchema);

    Playlist.create({title: 'C# for FFciopathsj', description: 'Descrip', category: 'Movies', video: 'video', date: Date.now(), creator: 'peshku', isPrivate: false, comments: [], totalAvgRating: 1});
    Playlist.create({title: 'C# for Non-Sociopa', description: 'Descrip', category: 'Movies', video: 'video', date: new Date('12/5/2013'), creator: 'peshku', isPrivate: false, comments: [], totalAvgRating: 1});
    Playlist.create({title: 'C# for Non-Sociopa', description: 'Descrip', category: 'Movies', video: 'video', date: new Date('10/5/2013'), creator: 'peshku', isPrivate: false, comments: [], totalAvgRating: 2});
};



