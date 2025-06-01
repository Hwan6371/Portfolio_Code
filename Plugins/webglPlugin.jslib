mergeInto(LibraryManager.library, {

  DeleteGetParameter: function () {
    history.replaceState({}, null, location.pathname);
  },

   IsMobileDevicePlatform: function () {
    return /iPhone|iPad|iPod|Android|webOS|BlackBerry|Windows Phone|Opera Mini|IEMobile|Mobile/i.test(navigator.userAgent);
  },

  getUrl: function ()
  {
      var returnStr = window.location.search;
      console.log(returnStr);
      history.replaceState({}, null, location.pathname);
      var bufferSize = lengthBytesUTF8(returnStr) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(returnStr, buffer, bufferSize);
      return buffer;
  },

  isMobile: function ()
    {
        if(navigator.maxTouchPoints <= 0)
            return false;
        return true;
    },
  
});