$(document).ready(function () {
    createHomeTopCarousel();
    var z = window.setInterval("goCarrossel()", 3000);
    createMiddleTopCarousel();
    createBottomCarousel();
    createDetailsTopCarousel();
});

function createHomeTopCarousel() {
    $(".top-scrollable-container").scrollable({
        speed: 600       
    });
}

function createDetailsTopCarousel() {
    $(".carousel-container-double .top-scrollable-container").scrollable({
        speed:600
    });
}

function createDetailsTopCarousel() {
    $(".carousel-container-double .bottom-scrollable-container item").click(function () {
        var carBott = $(".carousel-container-double .bottom-scrollable-container").data("scrollable");

        carBott.seek($(".carousel-container-double .bottom-scrollable-container item").index($(this)));
    });
    $(".carousel-container-double .bottom-scrollable-container").scrollable({
        speed: 600,
        onSeek:function()
        {
        var cartop = $(".carousel-container-double .top-scrollable-container").data("scrollable");
        cartop.getIndex(this.getIndex());
        }
    });
}
function goCarrossel() {
    var carousel = $(".top-scrollable-container").data("scrollable");
    console.info(carousel.getIndex() + "  " + carousel.getItems().length);
    if (carousel.getIndex() == carousel.getItems().length - 3) {
        carousel.seekTo(0);
    }
    else {
        carousel.next(400);
    }
}

function createMiddleTopCarousel() {
    window.qtdMidleFrameItens = 2;
    $(".mid-scrollable-container").scrollable({
        speed: 300,
        next: ".nexti",
        prev: ".previ",
        onSeek: function () {
            if (this.getIndex() >= 1) {
                $(".previ").css("visibility", "visible");
            }
            else {
                $(".previ").css("visibility", "hidden");
            }

            if (this.getIndex() < this.getItems().length - 2) {
                $(".nexti").css("visibility", "visible");
            }
            else {
                $(".nexti").css("visibility", "hidden");
            }
        }
    });
}

function createBottomCarousel() {
    window.qtdBottomFrameItens = 2;
    $(".bottom-scrollable-container").scrollable({
        next: ".next-btom",
        prev: ".prev-btom",
        onSeek: function () {
            console.info(this.getIndex() + " length" + this.getItems().length);
            
            if ($(".prev-btom").hasClass("disabled")) {
                $(".prev-btom").css("visibility", "hidden");
            }
            else{
                $(".prev-btom").css("visibility", "visible");
            }

            if ($(".next-btom").hasClass("disabled")) {
                $(".next-btom").css("visibility", "hidden");
            }
            else {
                $(".next-btom").css("visibility", "visible");
            }

        }
    });

}
     