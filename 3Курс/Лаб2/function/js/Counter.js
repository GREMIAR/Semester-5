function getTimeRemaining(endtime) {
    var t = Date.parse(endtime) - Date.parse(new Date());
    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return {'total': t,'days': days,'hours': hours,'minutes': minutes,'seconds': seconds};
}

function countdown() {
    endtime = '6/1/2023';
    var days = document.getElementById("days");
    var hours = document.getElementById("hours");
    var minutes = document.getElementById("minutes");
    var seconds = document.getElementById("seconds");
    function updateClock() {
        var t = getTimeRemaining(endtime);
        days.innerHTML = t.days;
        hours.innerHTML = ('0' + t.hours).slice(-2);
        minutes.innerHTML = ('0' + t.minutes).slice(-2);
        seconds.innerHTML = ('0' + t.seconds).slice(-2);
        if (t.total <= 0) 
        {
          clearInterval(timeinterval);
        }
    }
    updateClock();
    var timeinterval = setInterval(updateClock, 1000);
}

countdown();

function ModalOn(){
    var modal = document.getElementById('myModal');
    modal.style.display = "block";
}

function ModalOff() {
    var modal = document.getElementById('myModal');
    modal.style.display = "none";
}