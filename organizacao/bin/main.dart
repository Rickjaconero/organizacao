import 'package:twitter/twitter.dart';
import 'dart:io';

main() {
  Map twitterKeys = {
    "consumerKey": 'TXlcjpRTbZEgmkoxNT2oqCfeX',
    "consumerSecret": 'C5BzmoaPbLSoZ8De8qej7aSb0OCz0f2MlouLybtDdY5freEhNN',
    "accessToken": '97486111-ySo0byQk5B1KXHRMSNMTUABulYn4VRb1nC0aCNHgS',
    "accessSecret": 'ixkpMxe6dMMOhL4lKF5yFVgWbnleB8KtO0tJruqkV0EbI'
  };

  Twitter twitter = Twitter.fromMap(twitterKeys);

  String urlRequest = 'search/tweets.json?q=libertadores';

  try {
    var a = twitter.request("GET", urlRequest);
    a.then((value) {
      File("test.json").writeAsString(value.body);
      twitter.request("GET", urlRequest);
    }).then((value) {
      twitter.close();
    });
  } catch (e) {
    print(e);
  } finally {}

  return;
}
