const router = require('express').Router();
const db = require('../connection/database');

router.post('/getValue',(req,res) => {
    const id = req.body.id;
    const username = req.body.username;

    let sql = `SELECT username, value FROM balance WHERE id = ${id}`
    db.query(sql,(error,result) => {
        if(username == result[0].username){
            let value = ""+result[0].value
            res.end(value);
        }
        else{
            res.end("!");
        }
    })
});

router.post('/changeValue',async (req,res) => {
    const id = req.body.id;
    const username = req.body.username;
    const reqOperation = req.body.operation;
    const reqValue = + req.body.value;
    let curValue = 0;
    let newValue = 0;
    
    //Get Data form db.
    let sql = `SELECT username, value FROM balance WHERE id = ${id}`
    let result = await queryDB(sql);
    if(username == result[0].username){
        curValue = + result[0].value;
    }
    else{
        res.end("!");
    }

    //doing operation.
    if(reqOperation == "Add"){
        newValue = curValue + reqValue;
    }
    else{
        newValue = curValue - reqValue;
        if(newValue<0)
            return;
    }

    let sql2 = `UPDATE balance SET value = '${newValue}' WHERE id = '${id}'`;
    db.query(sql2,(error,result) => {
        res.end("Record updated successfully");
    })
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