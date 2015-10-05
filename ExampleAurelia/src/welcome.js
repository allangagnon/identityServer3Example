export class Welcome {
    heading = 'Welcome to the Example Aurelia App!';
    info = 'This is something';
}

export class UpperValueConverter {
  toView(value){
    return value && value.toUpperCase();
  }
}
