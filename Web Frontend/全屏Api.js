function launchFullscreen(element) {
    if(element.requestFullscreen) {
      element.requestFullscreen();
    } else if(element.mozRequestFullScreen) {
      element.mozRequestFullScreen();
    } else if(element.msRequestFullscreen){
      element.msRequestFullscreen();
    } else if(element.webkitRequestFullscreen) {
      element.webkitRequestFullScreen();
    }
  }


//进入全屏
launchFullscreen(document.documentElement);
//launchFullscreen(document.getElementById("id"));

//退出全屏
document.exitFullscreen();