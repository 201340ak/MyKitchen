import '../css/loginform.css';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';


export interface LoginProps extends RouteComponentProps<{}> {
    login: {
      [k: string]: string | Function
      username: string
      password: string
      logIn: Function
    }
  }
export class Login extends React.Component<LoginProps, {}> {
    update = (e: React.FormEvent<HTMLInputElement>): void => {
        this.props.login[e.currentTarget.name] = e.currentTarget.value
    }

      submit = (e: any): void => {
        Login;
        e.preventDefault();
      }

    public render() {
        var username = this.props.login.username;
        var password = this.props.login.password;
        return <div className="login">
                <h1>Log In</h1>
                    <input type="email" placeholder="Email" id="username" name="username" value={username} onChange={this.update} />  
                    <input type="password" placeholder="Password" id="password" name="password" value={password} onChange={this.update} /> 
                    <a href="#" className="register">Register</a>
                    <a href="#" className="forgot">Forgot Password?</a>
                    <br />
                    <input type="submit" value="Sign In" id="loginSubmit" onClick={this.submit} />
                </div>;
    }

    Login(): void
    {
        // TODO: How to trigger this?
        alert('Submit');

        // TODO: Replace with a post to "/api/sign-in" (How do I do that?)
    }

    // TODO: Add Login using Google Authentication.
}
