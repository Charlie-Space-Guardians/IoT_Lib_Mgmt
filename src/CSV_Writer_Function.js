// Function to generate a random date within the next two weeks
function getRandomDate() {
    var start = new Date();
    var end = new Date();
    end.setDate(start.getDate() + 14); // Two weeks from now
    return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
}

// Function to format date to a readable string
function formatDate(date) {
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var year = date.getFullYear();
    var hours = ("0" + date.getHours()).slice(-2);
    var minutes = ("0" + date.getMinutes()).slice(-2);
    return `${day}/${month}/${year} ${hours}:${minutes}`;
}

// Extract "Desk ID" and "Seat ID" from msg.topic
var topicParts = msg.topic.split('_');
var deskId = topicParts[1];
var seatId = topicParts[3];

// Generate random start and end times
var startDate = getRandomDate();
var endDate = new Date(startDate.getTime());
var durationMinutes = 15 + Math.floor(Math.random() * ((4 * 60) - 15));
endDate.setMinutes(startDate.getMinutes() + durationMinutes);

// Check if the end date is actually after the start date, if not adjust
if (endDate <= startDate) {
    endDate = new Date(startDate.getTime());
    endDate.setMinutes(startDate.getMinutes() + durationMinutes);
}

// Format dates to strings
var startStr = formatDate(startDate);
var endStr = formatDate(endDate);

// Create message payload with dynamic Desk ID and Seat ID
msg.payload = {
    "Desk ID": parseInt(deskId, 10),
    "Seat ID": parseInt(seatId, 10),
    "Start Time": startStr,
    "End Time": endStr,
    "Duration (Minutes)": durationMinutes, // Ensure this key matches the CSV column header
    "Peak Time Occupancy": Math.random() >= 0.5 // Randomly true or false
};

return msg;
