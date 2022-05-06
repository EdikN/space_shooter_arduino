let player = null;
let sdk = null;
let payments = null;
let ldName = 'shuter';

YaGames.init({
        adv: {
            onAdvClose: wasShown => {
                console.info('adv closed!');
            }
        }
    })
    .then(ysdk => {
        sdk = ysdk;
        sdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    console.log("closed");
                }
            }
        });
    });

function showFullscrenAd() {
    sdk.adv.showFullscreenAdv({ callbacks: {} })
}

function initPlayer() {
    return sdk.getPlayer({ signed: true }).then(_player => {
        player = _player;

        return player
    }).catch(err => {
        console.log(err);
    });
}

function getLidBoard() {
    sdk.getLeaderboards()
        .then(lb => {
            console.log(lb);
            lb.getLeaderboardEntries(ldName, { quantityTop: 10, includeUser: true, quantityAround: 3 }).then(res => {
                console.log(res);
                console.log('LidBoard getted');
                unityI.SendMessage("LidBoard", "SetLidBoardtoSV", JSON.stringify(res.entries));
            }).catch(err => console.log(err));
        });
}

function setLidBoard(num) {
    sdk.getLeaderboards()
        .then(lb => {
            console.log(lb);
            lb.setLeaderboardScore(ldName, Number(num));
        }).then(() => {
            getLidBoard();
        });
}

function login() {
    initPlayer().then(_player => {
        if (_player.getMode() === 'lite') {
            console.log('dont auth');
            sdk.auth.openAuthDialog().then(() => {
                console.log('logined');
                unityI.SendMessage("LidBoard", "Logined");
                lbInit();
                initPlayer().catch(err => {
                    console.log(err);
                });
            }).catch(() => {
                console.log('dont auth');
            });
        } else {
            console.log('logined');
            unityI.SendMessage("LidBoard", "Logined");
            lbInit();
        }
    }).catch(err => {
        console.log(err);
    });
}

function lbInit() {
    sdk.getLeaderboards()
        .then(lb => {
            console.log(lb);
            lb.getLeaderboardDescription(ldName).then(res => console.log(res));
            lb.getLeaderboardPlayerEntry(ldName).then(res => console.log(res)).catch(err => { console.log(err); });
        });
}

function showRewardedAd(id) {
    sdk.adv.showRewardedVideo({
        callbacks: {
            onOpen: () => {
                unityI.SendMessage('YandexSDK', 'OnRewardedOpen', id);
                console.log('Video ad open. Id: ' + id);
            },
            onRewarded: () => {
                unityI.SendMessage('YandexSDK', 'OnRewarded', id);
                console.log('Rewarded! Id: ' + id);
            },
            onClose: () => {
                unityI.SendMessage('YandexSDK', 'OnRewardedClose', id);
                console.log('Video ad closed. Id: ' + id);
            },
            onError: (e) => {
                var data = { "id": id, "error": error };
                unityI.SendMessage('YandexSDK', 'OnRewardedError', JSON.stringify(data));
                console.log('Error while open video ad:', e);
            }
        }
    })
}

function Start() {
    let data = sdk.environment;
    console.log(data);
    unityI.SendMessage("lang", "GettingLang", JSON.stringify(data));
}

function getDevice(){
    let data = sdk.deviceInfo;
    unityI.SendMessage("ship", "pcB", JSON.stringify(data))
}

function getUserData(){
    player.getData().then(stats =>{
      console.log('Data is getting');
      console.log(JSON.stringify(stats));
      unityI.SendMessage('YandexSDK', 'DataGetting', JSON.stringify(stats));
   });
}

function setUserData(_data){
    console.log('Try Save');
    console.log(_data);
    player.setData({data : _data}).then(()=>{
        console.log('saved');
        }).catch(()=>{console.log('unsaved')});
}

window.onbeforeunload = function(e) {
    console.log("Calling OnClose from Browser!");
    gameInstance.SendMessage("YandexSDK", "OnClose");

    let dialogText = "You game has been saved!  Would you like to continue unloading the page?";
    e.returnValue = dialogText;
    return dialogText;
};