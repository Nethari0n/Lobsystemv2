//Scan succes check if true background green
export   function IsTrue(isNot){
        if (isNot) {
            Succes();
        }
        else {
            Fail();
        }
    }

export   function Succes(){
        $(".scanBox").css("background-color", "#059862");
    }

export  function Fail(){
        $(".scanBox").css("background-color", "#bd0404 ");
    }


export  function IsTrueTitle(isNot){
        if (isNot) {
            SuccesTitle();
        }
        else {
            FailTitle();
        }
    }

export  function SuccesTitle(){
        $(".boxTitle").text("Succes");
    }

export   function FailTitle(){
        $(".boxTitle").text("Mislykkes");
    }


    //UID Input field
export  function FocusInput() {
        $("#UID").focus();
    }

export  function RemoveFocusSelect() {
        $("#PostSelecter").blur();
    }

export  function Show() {
        $('#UID').attr('readonly', false);
    }

export   function Hide() {
         $('#UID').attr('readonly', true);
    }


    //Timer
    let myTimeout;

export  function myStopFunction() {
      clearTimeout(myTimeout);
    }

export   function Normal() {
        $("#User").val("");
        $("#ErrorMessage").val("");
        $(".boxTitle").text("Klar");
        $(".scanBox").css("background-color", "#fff ");
    }

export  function Clear() {
        myTimeout = setTimeout(Normal, 3000);
    }


//Pop-up
export function InternetConnection(isNot) {
        if (!isNot) {
            if ($("#PopUp").hasClass("show")) { return; }
            $("#PopUp").addClass("show");
            $("#PopUp").removeClass("hide");
        }
        else {
            if (!$("#PopUp").hasClass("show")) { return; }
             $("#PopUp").removeClass("show");
             $("#PopUp").addClass("hide");

            setTimeout(() => { $("#PopUp").css("visibility", "hidden") }, 500);
        }
}




