
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

    $("#updateFeedbackButton").click(function (event) {
        debugger
        var statusId = selectedStatusId;
        var id = $("#recordIdInput").val();
        var remarks = $("#FeedbackByAdmin").val();

        // Client-side validation
        var errors = [];

        if (!statusId || isNaN(statusId) || statusId < 1) {
            errors.push("Action is required.");
        }

        if (!remarks) {
            errors.push("Remarks is required.");
        }

        if (errors.length > 0) {
            // Display validation errors to the user
            alert("Validation failed:\n" + errors.join("\n"));
            event.preventDefault(); // Prevent the default form submission behavior
        } else {
            var formData = new FormData();
            formData.append("id", id);
            formData.append("Action", statusId);
            formData.append("Remarks", remarks);
            debugger

            $.ajax({
                url: "/ClientInformationView/UpdateFeedback",
                type: "PUT",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.message === "Success") {
                        alert("Feedback updated successfully.");
                        window.location.href = '/ClientInformationView/Index';
                    } else {
                        alert("Update failed: " + data.message);
                    }
                },
                error: function (xhr, status, error) {
                    alert("Error: " + error);
                }
            });
        }
    });

});