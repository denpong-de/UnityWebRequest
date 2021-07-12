const mysql = require('mysql');

const con = mysql.createConnection({
    host     : 'localhost',
    user     : 'root',
    password : '',
    database : 'unity_web_request'
});

con.connect(err=>{
    if(err) throw err;
    else {
        console.log("SQL CONNECTED!");
    }
})

module.exports = con;