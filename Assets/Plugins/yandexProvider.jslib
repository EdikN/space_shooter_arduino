mergeInto(LibraryManager.library, {

    ShowFullscreenAd: function() {
        showFullscrenAd();
    },

    ShowRewardedAd: function(placement) {
        showRewardedAd(placement);
        console.log(placement);
        return placement;
    },

    ProjectStarted: function() {
        Start();
    },

    SetLidBoard: function(num) {
        setLidBoard(num);
    },

    GetLidBoard: function() {
        getLidBoard();
    },

    Login: function() {
        login();
    },

    GetDevice: function() {
        getDevice();
    },

    LoadY: function() {
      getUserData();
    },

    SaveY: function(data) {
      setUserData(UTF8ToString(data));
    },
});