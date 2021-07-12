const fs = require('fs');
const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const hostname = 'localhost';
const port = 3000;

app.use(express.static(__dirname));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: false}))

app.get('/get',(req,res) => {
    getValue(req,res);
});

app.post('/post',(req,res) => {
    postValue(req,res);
});

const getValue = async (req,res) => {
    let value = await readFile();
    res.writeHead(200,{'Content-Type': 'text/html'});
    res.write(value);
    res.end();
}

const postValue = async (req,res) => {
    let reqOperation = req.body.operation;
    let reqValue = req.body.value;  
    let fileValue = + await readFile();
    let newFileValue;
    if(reqOperation == "Add"){
        newFileValue = fileValue + reqValue;
    }
    else{
        newFileValue = fileValue - reqValue;
        if(newFileValue<0)
            return;
    }
    let dataString = '' + newFileValue;
    let value = await writeFile(dataString);
}

let readFile = () => {
    return new Promise((resolve,reject) => {
        fs.readFile('value.txt',(err,data) => {
            if(err){
                reject(err);
            } 
            else{
                console.log(data);
                resolve(data);
            }
        });
    })
}

let writeFile = (newData) => {
    return new Promise((resolve,reject) => {
        fs.writeFile('value.txt', newData, (err) => {
            if(err){
                reject(err);
            }
            else{
                console.log(newData);
                resolve(newData);
            }
        });
    })
}

app.listen(port, hostname, (error) => {
    if(error){
        console.log('Something went wrong',error)
    } 
    else{
        console.log(`Server running at http://${hostname}:${port}/`);
    }
});