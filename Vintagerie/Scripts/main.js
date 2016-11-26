$(document).ready(function() {
    $(window).on("scroll", function() {
        var getDistance = $(window).scrollTop();
        if (getDistance > 150) {
           
            $(".navbar").addClass("topMe");

        }
        else
        {
            $(".navbar").removeClass("topMe");

        }
    });
})