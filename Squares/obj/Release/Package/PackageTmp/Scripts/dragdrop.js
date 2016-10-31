// Double click to rotate
var angle = 90;

$('.square').dblclick(function () {
    $(this).css({
        '-webkit-transform': 'rotate(' + angle + 'deg)',
        '-moz-transform': 'rotate(' + angle + 'deg)',
        '-o-transform': 'rotate(' + angle + 'deg)',
        '-ms-transform': 'rotate(' + angle + 'deg)'
    });
    angle += 90;
});


$(function () {

    $(".edit-button").click(function () {
        $(".outter-editor").toggle();

    });

    $(".back-to-reality").click(function () {
        $(".outter-editor").toggle();
    });
});

//Drag Events 
$(function () {

    var field1 = 0,
        field2 = 0,
        field3 = 0,
        field4 = 0,
        field5 = 0,
        field6 = 0,
        field7 = 0,
        field8 = 0,
        field9 = 0;

    $(".draggable").draggable({
        start: function () { },
        drag: function () {
            //            console.log("dragging");
        },
        stop: function () {
            var currentlyDroppedCellLeft = Math.ceil($(this).position().left),
                currentlyDroppedCellTop = Math.ceil($(this).position().top),
                c1Left = Math.ceil($("#c1").position().left),
                c1Top = Math.ceil($("#c1").position().top),
                c2Left = Math.ceil($("#c2").position().left),
                c2Top = Math.ceil($("#c2").position().top),
                c3Left = Math.ceil($("#c3").position().left),
                c3Top = Math.ceil($("#c3").position().top),
                c4Left = Math.ceil($("#c4").position().left),
                c4Top = Math.ceil($("#c4").position().top),
                c5Left = Math.ceil($("#c5").position().left),
                c5Top = Math.ceil($("#c5").position().top),
                c6Left = Math.ceil($("#c6").position().left),
                c6Top = Math.ceil($("#c6").position().top),
                c7Left = Math.ceil($("#c7").position().left),
                c7Top = Math.ceil($("#c7").position().top),
                c8Left = Math.ceil($("#c8").position().left),
                c8Top = Math.ceil($("#c8").position().top),
                c9Left = Math.ceil($("#c9").position().left),
                c9Top = Math.ceil($("#c9").position().top);


            if ((currentlyDroppedCellLeft - c1Left + 1 == 0 || currentlyDroppedCellLeft - c1Left == 0 || currentlyDroppedCellLeft - c1Left - 1 == 0) && (currentlyDroppedCellTop - c1Top == 0 || currentlyDroppedCellTop - c1Top - 1 == 0 || currentlyDroppedCellTop - c1Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square1 = (this.id); // The dropped piece                
                if (document.getElementById("outputfield").value.indexOf("field1=" + square1 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field1=" + square1 + ",")
                }
                //END OF FIELD OUTPUT
            }
            else if ((currentlyDroppedCellLeft - c2Left + 1 == 0 || currentlyDroppedCellLeft - c2Left == 0 || currentlyDroppedCellLeft - c2Left - 1 == 0) && (currentlyDroppedCellTop - c2Top == 0 || currentlyDroppedCellTop - c2Top - 1 == 0 || currentlyDroppedCellTop - c2Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square2 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field2=" + square2 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field2=" + square2 + ",")
                }
                //END OF FIELD OUTPUT
            }
            else if ((currentlyDroppedCellLeft - c3Left + 1 == 0 || currentlyDroppedCellLeft - c3Left == 0 || currentlyDroppedCellLeft - c3Left - 1 == 0) && (currentlyDroppedCellTop - c3Top == 0 || currentlyDroppedCellTop - c3Top - 1 == 0 || currentlyDroppedCellTop - c3Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square3 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field3=" + square3 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field3=" + square3 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c4Left + 1 == 0 || currentlyDroppedCellLeft - c4Left == 0 || currentlyDroppedCellLeft - c4Left - 1 == 0) && (currentlyDroppedCellTop - c4Top == 0 || currentlyDroppedCellTop - c4Top - 1 == 0 || currentlyDroppedCellTop - c4Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square4 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field4=" + square4 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field4=" + square4 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c5Left + 1 == 0 || currentlyDroppedCellLeft - c5Left == 0 || currentlyDroppedCellLeft - c5Left - 1 == 0) && (currentlyDroppedCellTop - c5Top == 0 || currentlyDroppedCellTop - c5Top - 1 == 0 || currentlyDroppedCellTop - c5Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square5 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field5=" + square5 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field5=" + square5 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c6Left + 1 == 0 || currentlyDroppedCellLeft - c6Left == 0 || currentlyDroppedCellLeft - c6Left - 1 == 0) && (currentlyDroppedCellTop - c6Top == 0 || currentlyDroppedCellTop - c6Top - 1 == 0 || currentlyDroppedCellTop - c6Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square6 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field6=" + square6 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field6=" + square6 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c7Left + 1 == 0 || currentlyDroppedCellLeft - c7Left == 0 || currentlyDroppedCellLeft - c7Left - 1 == 0) && (currentlyDroppedCellTop - c7Top == 0 || currentlyDroppedCellTop - c7Top - 1 == 0 || currentlyDroppedCellTop - c7Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square7 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field7=" + square7 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field7=" + square7 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c8Left + 1 == 0 || currentlyDroppedCellLeft - c8Left == 0 || currentlyDroppedCellLeft - c8Left - 1 == 0) && (currentlyDroppedCellTop - c8Top == 0 || currentlyDroppedCellTop - c8Top - 1 == 0 || currentlyDroppedCellTop - c8Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square8 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field8=" + square8 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field8=" + square8 + ",")
                }
                //END OF FIELD OUTPUT
            } else if ((currentlyDroppedCellLeft - c9Left + 1 == 0 || currentlyDroppedCellLeft - c9Left == 0 || currentlyDroppedCellLeft - c9Left - 1 == 0) && (currentlyDroppedCellTop - c9Top == 0 || currentlyDroppedCellTop - c9Top - 1 == 0 || currentlyDroppedCellTop - c9Top + 1 == 0)) {
                //OUTPUT TO DUMMY FIELD
                square9 = (this.id); // or get the background image;
                if (document.getElementById("outputfield").value.indexOf("field9=" + square9 + ",") >= 0) {
                    console.log('Square already in string');
                }
                else {
                    var outputfield = $('#outputfield');
                    outputfield.val(outputfield.val() + "field9=" + square9 + ",")
                }
                //END OF FIELD OUTPUT
            }




            //            alert(aTop);
            //            alert(bTop);
            console.log("stopped");
            //            console.log($(this).position().left);
            //            console.log($(this).attr('id'));
            //                    if($(this).position().left>20){
            //                            $(this).draggable({ revert: true });
            //
            //                    }
        }
    });
});



//Draggable
$(".draggable").draggable({
    snap: ".grid-cell",
    snapMode: "inner",
    //helper: "clone",
    opacity: 0.7,
    cursor: "move",
    cursorAt: {
        top: 50,
        left: 50
    },
    containment: "#editor-frame",
    scroll: false,
});

//Droppable
$(".droppable").droppable({
    activeClass: "square-drag",
    hoverClass: "ui-state-hover",
    drop: function (event, ui) {
        $(this)
            .addClass("ui-state-highlight");
    }
});







// Reset tile position when dragged out of droppable area.
$(function () {
    $(".draggable").draggable({
        revert: function (event, ui) {
            $(this).data("uiDraggable").originalPosition = {
                top: 0,
                left: 0
            };
            return !event;
        }
    });
    $(".droppable").droppable();
});




