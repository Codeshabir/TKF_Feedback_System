
$(document).ready(function () {
    var selectedStatusId;
    var id;
    $(".dropdown-item").click(function (e) {
        debugger
        e.preventDefault();
        selectedStatusId = $(this).attr("value");

        $("#actionDropdown").text($(this).text());

        $("#statusIdInput").val(selectedStatusId);

    });

    $("#updateFeedbackButton").click(function () {
        debugger
        var statusId = selectedStatusId;
        id = $("#recordIdInput").val();
        var remarks = $("#FeedbackByAdmin").val();

        var formData = new FormData();
        formData.append("id", id);
        formData.append("Action", statusId);
        formData.append("Remarks", remarks);

        $.ajax({
            url: "/ClientInformationView/UpdateFeedback",
            type: "POST", 
            data: formData,
            processData: false, 
            contentType: false, 
            success: function () {
                alert("Feedback updated successfully.");
               // window.location.href = '/ClientInformationView/Index';

            },
            error: function (xhr, status, error) {
                alert("Error: " + error);
            }
        });
    });
});