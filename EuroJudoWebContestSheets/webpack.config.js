const path = require('path');
const webpack = require('webpack');

module.exports = {
    mode: 'development',
    entry: { 'main': './ClientApp/js/app.js'},
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        filename: 'bundle.js',
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