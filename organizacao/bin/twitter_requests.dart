import 'dart:io';

import 'package:twitter/twitter.dart';

class TwitterRequest {

  Map twitterKeys = {
    "consumerKey": 'TXlcjpRTbZEgmkoxNT2oqCfeX',
    "consumerSecret": 'C5BzmoaPbLSoZ8De8qej7aSb0OCz0f2MlouLybtDdY5freEhNN',
    "accessToken": '97486111-ySo0byQk5B1KXHRMSNMTUABulYn4VRb1nC0aCNHgS',
    "accessSecret": 'ixkpMxe6dMMOhL4lKF5yFVgWbnleB8KtO0tJruqkV0EbI'
  };

  Future<void> UserScreenNameSearch(String screenName) async{

    Twitter twitter = Twitter.fromMap(twitterKeys);

    String urlRequest = 'statuses/user_timeline.json?screen_name=${screenName}';

    try {
      var a = twitter.request("GET", urlRequest);
      await a.then((value) {
        File("${screenName}.json").writeAsString(value.body);
        twitter.request("GET", urlRequest);
      }).then((value) {
        twitter.close();
      });
    } catch (e) {
      print(e);
    } finally {}
  }


}