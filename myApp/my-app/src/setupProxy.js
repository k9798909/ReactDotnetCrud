const { createProxyMiddleware } = require('http-proxy-middleware');
const proxy = {
    target: 'https://localhost:7052/',
    changeOrigin: true,
    secure: false,
}
module.exports = function(app) {
  app.use(
    '/api',
    createProxyMiddleware(proxy)
  );
};

// ,
//   "proxy": "https://localhost:7052/"