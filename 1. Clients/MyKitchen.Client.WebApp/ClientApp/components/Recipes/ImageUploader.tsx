import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as $ from 'jquery';
import '../../css/uploadimage.css';

interface ImageUploaderComponentState{
    image?: File;
}

export interface ImageUploaderComponentProps
{
   getImage(file: File): any;
}

export class ImageUploaderComponent extends React.Component<ImageUploaderComponentProps, ImageUploaderComponentState> {
    
    constructor() {
        super();
    }

    public render() {
        return <div className="image-uploader-container">
        <input id="image-uploader-input" type="file" hidden={true} onChange={e => this.ShowFileWasSelected(e)} />
        <div id="image-uploader" className="image-uploader">
            <span className="glyphicon glyphicon-camera" aria-hidden="true"></span>
            <p>Upload a delicious picture!</p>
            </div>
        </div>;
    }

    private ShowFileWasSelected(event: React.ChangeEvent<HTMLInputElement>)
    {
        var file = event.target.files![0];
        this.setState({image: file});
        var reader = new FileReader();
        var fileText = reader.readAsDataURL(file);
        reader.onload = function (evt) {
            var fileContent = reader.result;
            $('#image-uploader').css("background-image", "url(" +fileContent +")");
        }
        this.props.getImage(file);
    }
}