
const urlParams = new URLSearchParams(window.location.search);
const keyCode = urlParams.get('gameCode');
const userName = urlParams.get('userName');
const isGameOwner = urlParams.get('isGameOwner');
const url = "/answer-repair-signalr";

(function () {
    
    abp.signalr = abp.signalr || {};
    abp.signalr.autoConnect = false;
    abp.signalr.url = url;
    console.log(abp.signalr);
    abp.signalr.startConnection(url).then(function (connection) {
        if (isGameOwner) {
            connection.invoke('CreateGame', keyCode).then(function () {
                abp.log.debug('Game Created!');
            });
        } else {
            connection.invoke('JoinGame', keyCode).then(function () {
                abp.log.debug('Joined game!');
            });
        }
    });
})();
