const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://cruddapp.azurewebsites.net` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://cruddapp.azurewebsites.net';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
