const express = require('express');
const app = express();
const cors = require('cors');
const bodyParser = require('body-parser');
const hostname = 'localhost';
const port = 3000;

app.use(cors());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use('/api',require('./routes/auth'));
app.use('/api',require('./routes/banner'));
app.use('/api',require('./routes/balance'));

app.listen(port, hostname, (error) => {
    if(error){
        console.log('Something went wrong',error)
    } 
    else{
        console.log(`Server running at http://${hostname}:${port}/`);
    }
});