const router = require('express').Router();
const db = require('../connection/database');

router.post('/login',(req,res) => {
    const username = req.body.username;
    const password = req.body.password;
    let sql = `SELECT id, password FROM account WHERE username = '${username}'`
    db.query(sql,(error,result) => {
        if(result.length > 0){
            if(password == result[0].password){
                let id = ""+result[0].id
                res.end(id);
            }
            else{
                res.end("!");
            }
        }
        else{
            res.end("!");
        }
    })
});

router.post('/register',async(req,res) => {
    const username = req.body.username;
    const password = req.body.password;
    let sql = `INSERT INTO account (username,password) VALUES ("${username}","${password}")`
    db.query(sql,(error,result) => {
        if(error){
            res.end("!");
        }
    })
    let sql2 = `INSERT INTO balance (username,value) VALUES ("${username}",'10')`
    let result = await queryDB(sql2);
    res.end("OK");
});

const queryDB = (sql) => {
    return new Promise((resolve,reject) => {
        // query method
        db.query(sql, (err,result, fields) => {
            if (err) reject(err);
            else
                resolve(result)
        })
    })
}

module.exports = router;