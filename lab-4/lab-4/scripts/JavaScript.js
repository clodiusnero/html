function playSound(soundfile) {
    document.getElementById("gamemouse").innerHTML =
      "<embed src=\"" + soundfile + "\" hidden=\"true\" autostart=\"true\" loop=\"false\" />";
}