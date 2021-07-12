const router = require('express').Router();
const db = require('../connection/database');

router.post('/checkBanner',(req,res) => {
    const localBannerId = + req.body.localBannerId;
    let sql = `SELECT * FROM banner order by id desc`
    db.query(sql,(error,result) => {
        if(localBannerId != result[0].id){
            let send = result[0].id + ";" + result[0].url;
            res.end(send);
        }
        else{
            res.end("OK");
        }
    })
});

module.exports = router;