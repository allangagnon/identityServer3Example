import {AuthorizeStep} from 'devscott/aurelia-auth';  
import {inject} from 'aurelia-framework';  
import {Router} from 'aurelia-router';

@inject(Router)
export default class{

    constructor(router) {
        this.router = router;
    };
    
    configure(){
        var appRouterConfig = function(config){
            config.title = 'Example Aurelia App';
            config.addPipelineStep('authorize', AuthorizeStep);
       
            config.map([
                { route: ['','welcome'],  name: 'welcome',      moduleId: 'welcome',      nav: true, title:'Welcome' },
                { route: 'users',         name: 'users',        moduleId: 'users',        nav: true, title:'Github Users', auth:true },
                { route: 'login', name: 'login', moduleId: './login', nav: false, title:'Login'},
                { route: 'logout', name: 'logout', moduleId: './logout', nav: false, title:'Logout', auth: true }
            ]);
        };
        this.router.configure(appRouterConfig);
    };
}