import 'dart:convert' as Json;
import 'dart:io';
import 'twitter_requests.dart';

main() async {

  String busca = "foxsportsbrasil"
  await TwitterRequest().UserScreenNameSearch(busca);

  String json = await File('$busca.json').readAsString();
  List twitterJson = Json.jsonDecode(json);
  int count = 0;
  twitterJson.forEach((elemento){
    if(elemento["text"].toString().contains("Champions League")){
      print(elemento["text"]);
      count++;
    }
  });
  print("\n$count");

  count = 0;
  twitterJson.forEach((elemento){
    if(elemento["text"].toString().contains("Libertadores")){
      print(elemento["text"]);
      count++;
    }
  });
  print("\n$count");
}
