const PORT = 3000;
const io = require("socket.io")(PORT, {
    cors: {
        origin: "*",
        methods: ["GET", "POST"],
    }
});

io.on("connection", socket => {
    socket.on("hello", data => {
        console.log(data);
    });
    socket.on("screen", data => {
        io.emit("screen", data);
    });
});