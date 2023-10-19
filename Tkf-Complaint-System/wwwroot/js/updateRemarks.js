
    $(document).ready(function () {
        var selectedStatusId;
        var id;
        $(".dropdown-item").click(function (e) {
            debugger
            e.preventDefault();
            // Get the ID of the clicked dropdown item.
            selectedStatusId = $(this).attr("value");

            // Set the selected status ID in the button text.
            $("#actionDropdown").text($(this).text());

            // Store the selected status ID in a hidden input field.
            $("#statusIdInput").val(selectedStatusId);
           
        });

    $("#updateFeedbackButton").click(function () {
            debugger
        // Get the Status ID, Record ID, and Remarks from your form or other source.
        var statusId = selectedStatusId;
    id = $("#recordIdInput").val(); // Retrieve the record ID.
    var remarks = $("#FeedbackByAdmin").val();

    // Create a data object to send in the AJAX request.
        var data = {
   // id = id// Include the Record ID in the data.
    Action: statusId, // Assuming you want to update the "Action" field with the Status ID.
    Remarks: remarks
            };

    // Send an AJAX PUT request to update the feedback.
    $.ajax({
                
    url: "/api/ClientInformation/feedback/" + id ,
    type: "PUT",
    contentType: "application/json",
    data: JSON.stringify(data),
    success: function () {
                    debugger
    alert("Feedback updated successfully.");
                },
    error: function (xhr, status, error) {
        alert("Error: " + error);
                }
            });
        });
    });
