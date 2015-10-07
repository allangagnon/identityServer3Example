import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-http-client';

@inject(HttpClient)
export class Users {
  heading = 'People';
  users = [];

  url = 'http://localhost:50316/api/People';
  constructor(http) {
      this.http = http;
  };

  activate() {
      return this.http.get(this.url)
                      .then(response => this.users = response.content)['catch'](function (err) {
                          console.log("blah");
                          throw err;
                      });
  }
}
