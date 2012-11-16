$(document).ready(function () {
    createCarrouselTop();
    createDetailsTopCarousel();
});

function createCarrouselTop() {
    $(".top-scrollable-container").scrollable({
        speed: 600
    });
}
function createDetailsTopCarousel() {
    console.info('k');
    $(".bottom-scrollable-container .item").live("click",function () {
        console.info('ok');
        var carBott = $(".top-scrollable-container").data("scrollable");

        carBott.seekTo($(".bottom-scrollable-container .item").index($(this)));
    });
    $(".bottom-scrollable-container").scrollable({
        speed: 600,
        onSeek:function()
        {
        var cartop = $(".top-scrollable-container").data("scrollable");
        cartop.getIndex(this.getIndex());
        }
    });
}
