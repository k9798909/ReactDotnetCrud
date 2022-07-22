import React from 'react'
import './Layout.scss'
import logo from '../../logo.svg';
import {
    Link,
} from "react-router-dom";


const Layout = (props) => {
    const item = (name, href) => {
        return (
            <li><Link className='p-2 white' to={href}>{name}</Link></li>
        );
    }

    const userStatus = () => {
        let cut = '|';
        return (
            <div>
                <a className='white' href='/'>註冊</a>{cut}<a className='white' href='/'>登入</a>
            </div>
        );
    }

    return (
        <div className='layout'>
            <div className='header'>
                <div className='container-flud h-100'>
                    <div className='row w-100 h-100 align-items-center'>
                        <div className='col-1'>
                            <img src={logo} className="logo" alt="logo" />
                        </div>
                        <ul className='col-9 d-flex justify-content-around'>
                            {item('商城', '/mall')}
                            {item('訂單管理', '/')}
                            {item('個人資訊', '/')}
                            {item('商品上架', '/product')}
                        </ul>
                        <div className='col-2 p-0'>
                            {userStatus()}
                        </div>
                    </div>
                </div>
            </div>
            <div className="content">
                {props.children}
            </div>
        </div>
    );
}


export default Layout;