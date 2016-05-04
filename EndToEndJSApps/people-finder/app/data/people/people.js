var mongoose = require('mongoose');

var Person = mongoose.model('Person');

function save(){

}

function getById(id){

}

function getAll(){

}

module.exports = {
    save: save,
    all: getAll,
    byId: getById
};