import React, { useState, useEffect } from "react";
import logo from '../../logo.svg';
import './Mall.scss';

const Mall = () => {
    const [productArray, setProductArray] = useState([]);
    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch('api/Product');
                const json = await response.json();
                setProductArray(json);
            } catch (e) {
                console.error(e);
            }
        };
        fetchData();
    },[]);

    const productItem = (product, i) => {
        return (
            <li className="my-2" key={i}>
                <div className="d-flex flex-column align-items-center">
                    <div>
                        <img src={logo} alt="logo" />
                    </div>
                    <div>
                    </div>
                    <div><b>{product.proname}</b></div>
                    <div className="w-100 d-flex justify-content-around"><div>${product.proprice}</div><div>數量:{product.proqty}</div></div>
                    <div>
                        {dtBtn()}
                    </div>
                </div>
            </li>
        )
    }

    const dtBtn = () => {
        return (<button className="btn btn-primary btn-sm">商品名細</button>);
    }

    return (
        <div className="Mall">
            <div className="container">
                <ul className="d-flex flex-wrap justify-content-between">
                    {productArray.map((product, i) => productItem(product, i))}
                </ul>
            </div>
        </div>
    )
}

export default Mall;