$(document).ready(function () {
    const popupContainer = $("#popup-container");
    const popupTitle = $("#popup-title");
    const popupContent = $("#popup-content");

   window.loadPopup = function (title, pageUrl) {
    popupTitle.text(title);
    popupContent.empty(); // Clear previous content
    
    popupContent.load(`${pageUrl}?t=${new Date().getTime()}`, function (response, status, xhr) {
        if (status === "error") {
            alert("Failed to load content.");
        } else {
            if (pageUrl === "scan.html") {
                resetScanPage();
                loadSystemFolders();
            }
        }
    });

    popupContainer.show();
};

function resetScanPage() {
    $('#folderSelect').empty();
    $('#fileTable').empty();
    $('#scanningPopup').hide();
    $('#scanCompletionModal').hide();
}



    function displayErrorMessage(message) {
        alert(message);
    }

    $("#close").click(function () {
        popupContainer.hide();
    });

    $("#minimize").click(function () {
        popupContainer.css("height", "50px");
        popupContent.hide();
    });

    $("#popup-header").dblclick(function () {
        popupContainer.css("height", "auto");
        popupContent.show();
    });

    loadPopup("Login", "login.html");

    $(document).on("click", "#scan-button", function () {
        loadPopup("Scan", "scan.html");
    });

    $(document).on("click", "#print-button", function () {
        loadPopup("Print", "print.html");
    });

    $(document).on("click", "#back-button", function () {
       loadPopup("select-operation", "select-operation.html");
    });

    $(document).on("click", "#logout", function () {
        loadPopup("Login", "login.html");
    });
});

