function onButtonClick(event, args) {
    'use strict';
    var currentWindow = window,
        currentBrowser = currentWindow.navigator.appCodeName,
        browserIsMozilla = currentBrowser === 'Mozilla';
    if (browserIsMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}