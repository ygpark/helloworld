var request = require("request");


//var ip = "61.40.211.106"
var ip = "127.0.0.1"
var API_KEY = "2016080409332447715331"

respond = ""
var uri = "http://whois.kisa.or.kr/openapi/whois.jsp?query=" + ip + "&key=" + API_KEY + "&answer=json"

request({
  uri: uri,
}, function(error, response, body) {

  var whois = JSON.parse(body).whois;
  
  console.log(body);
  console.log(whois.query);
  console.log(whois.countryCode);
  console.log(whois.registry);

  if(whois.korean && whois.korean.ISP) {
    console.log(whois.korean.ISP.netinfo.range + "(" + ISP.netinfo.prefix + ")");
    console.log(whois.korean.ISP.netinfo.orgName);
    console.log(whois.korean.ISP.netinfo.servName);
    console.log(whois.korean.ISP.netinfo.addr);
  }

  if(whois.korean && whois.korean.user) {
    console.log(user.netinfo.range + "(" + user.netinfo.prefix + ")");
    console.log(user.netinfo.orgName);
    console.log(user.netinfo.servName);
    console.log(user.netinfo.addr);
  }
});

