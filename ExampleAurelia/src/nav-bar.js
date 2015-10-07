import {bindable} from 'aurelia-framework';  
import {inject} from 'aurelia-framework';  
import {computedFrom} from 'aurelia-framework';  
import {AuthService} from 'aurelia-auth';

@inject(AuthService)
export class NavBar {  
    // User isn't authenticated by default
    _isAuthenticated = false;
    profile = {}; 
    @bindable router = null;

    // We can check if the user is authenticated
    // to conditionally hide or show nav bar items
    get isAuthenticated() {
        this._isAuthenticated = this.auth.isAuthenticated();
        return this._isAuthenticated;
    };

    @computedFrom('profile')
    get displayName(){
        return `${this.profile.given_name} ${this.profile.family_name}`;
    }

    constructor(auth) {
        this.auth = auth;      
        this._isAuthenticated = this.auth.isAuthenticated();

        if(this._isAuthenticated)
        {
            this.auth.getMe().then(data => { this.profile = data});
        }
    };
}