const path = require('path');

module.exports = {
    mode: 'development',
    entry: { 'contest': './ClientApp/js/contest.js', 'sheet': './ClientApp/js/sheet.js'},
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        filename: 'bundle-[name].js',
        publicPath: 'js/'
    }
};