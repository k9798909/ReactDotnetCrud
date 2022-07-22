import React, { useState, useEffect } from 'react';
import './Product.scss';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Formik, Field, Form } from "formik";

const Action = {
    Query: '明細',
    Add: '新增',
    Edit: '修改',
}
Object.freeze(Action);

const Product = (props) => {
    const [show, setShow] = useState(false);
    const [action, setAction] = useState(Action.Query);
    const [productArray, setProductArray] = useState([]);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const addModalShow = () => {
        setAction(Action.Add);
        handleShow();
    }



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
    }, []);

    const ActionModal = () => {
        async function productFormSubmit(values) {
            console.log(JSON.stringify(values))
            fetch('api/product',
                {
                    method: 'POST',
                    body: JSON.stringify(values),
                    headers: new Headers({
                        'Content-Type': 'application/json'
                    })
                })
                .then(res => res.json())
                .then(json => setProductArray(productArray.concat(json)))
                .catch(e => { console.log(e) })
        }

        return (
            <>
                <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>商品{action}</Modal.Title>
                    </Modal.Header>
                    <Formik
                        initialValues={
                            {
                                proid: null,
                                proname: '',
                                proprice: 0,
                                proqty: 0
                            }
                        }
                        onSubmit={(value) => productFormSubmit(value)}
                    >
                        <Form>
                            <Modal.Body>
                                <div className="d-flex mb-2">
                                    <label htmlFor="proname" className="col-form-label">產品名稱：</label>
                                    <Field name="proname" type="text" className="form-control w-50" />
                                </div>
                                <div>
                                    <div className="d-flex mb-2">
                                        <label htmlFor="proprice" className="col-form-label">產品價錢：</label>
                                        <Field name="proprice" type="text" className="form-control w-50" />
                                    </div>
                                    <div className="d-flex mb-2">
                                        <label htmlFor="proqty" className="col-form-label">產品數量：</label>
                                        <Field name="proqty" type="text" className="form-control w-50" />
                                    </div>
                                </div>

                            </Modal.Body>
                            <Modal.Footer>
                                <Button variant="secondary" onClick={handleClose}>
                                    取消
                                </Button>
                                <Button variant="primary" type="submit" onClick={handleClose}>
                                    確認
                                </Button>
                            </Modal.Footer>
                        </Form>
                    </Formik>
                </Modal>
            </>
        )
    }

    return (
        <div className="product">
            <div className="container py-3">
                <div className="d-flex justify-content-end pb-3">
                    <button className="btn btn-outline-success mx-3" onClick={addModalShow}>新增</button>
                    <button className="btn btn-outline-danger mx-3">刪除</button>
                </div>
                <table className="table">
                    <thead>
                        <tr className="text-center">
                            <th scope="col">#</th>
                            <th scope="col">序號</th>
                            <th scope="col">商品編號</th>
                            <th scope="col">商品名稱</th>
                            <th scope="col">商品價錢</th>
                            <th scope="col">商品數量</th>
                            <th scope="col">商品明細</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            productArray.map((product, i) =>
                            (
                                <tr className="text-center align-middle" key={i}>
                                    <td><input className="form-check-input" type="checkbox" /></td>
                                    <th scope="row">{++i}</th>
                                    <td>{product.proid}</td>
                                    <td>{product.proname}</td>
                                    <td>{product.proprice}</td>
                                    <td>{product.proqty}</td>
                                    <td><button className="btn btn-primary">明細</button></td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>

            {ActionModal()}
        </div>
    )


}

export default Product;
