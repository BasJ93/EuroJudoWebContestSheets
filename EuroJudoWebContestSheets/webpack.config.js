const path = require('path');
const webpack = require('webpack');

module.exports = {
    mode: 'development',
    entry: { 'contest': './ClientApp/js/contest.js', 'sheet': './ClientApp/js/sheet.js'},
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        filename: 'bundle-[name].js',
        publicPath: 'js/'
    }/*,
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery'
        })

    ]*/
};