import React from "react";
import {RouteComponentProps} from "react-router";
import {DocumentIOMenu} from "../../components/menu";

export const CardsPage = (props: RouteComponentProps) => {
    return (
        <>
            <DocumentIOMenu logoUrl='/' {...props} search dropdown/>

        </>
    )
}