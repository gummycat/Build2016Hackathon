﻿var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function (req, res) {
    res.render('index', { title: 'Build2016Hackathon' });
});

module.exports = router;