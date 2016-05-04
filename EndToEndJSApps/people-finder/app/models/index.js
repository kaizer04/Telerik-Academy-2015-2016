var fs = require('fs');

fs.readdir(__dirname + '/models',
    function(err, files){
        if(err){throw err;}
        for(var i = 0, len = files.length; i < len; i=+1){
            require('./models/'+ files[i]);
        }
    });