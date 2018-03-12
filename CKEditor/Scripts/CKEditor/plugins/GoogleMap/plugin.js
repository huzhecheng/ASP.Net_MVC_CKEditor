(function () {

    CKEDITOR.plugins.add('GoogleMap', {
        //requires: "GoogleMap",

        init: function (editor) {
			editor.addCommand('GoogleMap', new CKEDITOR.dialogCommand('GoogleMap'));

            editor.ui.addButton('GoogleMap', {
                label: '自訂GoogleMap',
				icon: '/Scripts/CKEditor/plugins/GoogleMap/icons/if_map_283048.png',
				command: 'GoogleMap',
            });


			CKEDITOR.dialog.add('GoogleMap', function (editor) {

                var textStyle = 'width:150px;height:30px';

                var model = {
                    title: '自訂GoogleMap',
                    minWidth: 250,
                    minHeight: 250,
                    contents: [{
                        id: 'GoogleMapControl',
                        label: '自訂GoogleMap',
                        title: '自訂GoogleMap',
                        elements: [
                            {
                                id: 'mapAddress',
                                type: 'text',
                                label: '請輸入地址',
                            },
                            {
                                id: 'mapWidth',
                                type: 'text',
                                label: '地圖寬度',
                                'default': '425'
                            },

                            {
                                id: 'mapHeight',
                                type: 'text',
                                label: '地圖高度',
                                'default': '350'
                            },

                        ]

                    }],
                    buttons: [CKEDITOR.dialog.okButton, CKEDITOR.dialog.cancelButton],
                    onOk: function () {
                        // "this" is now a CKEDITOR.dialog object.
                        // Accessing dialog elements:

                        var address = this.getValueOf('GoogleMapControl', 'mapAddress');
                        var width = this.getValueOf('GoogleMapControl', 'mapWidth');
                        var height = this.getValueOf('GoogleMapControl', 'mapHeight');



                        var strElement = '<div>';
                        strElement += '<iframe width="' + width + '" height="' + height + '"';
                        strElement += 'frameborder = "0" scrolling= "no" marginheight= "0" marginwidth= "0"';
                        strElement += 'src = "http://maps.google.com.tw/maps?f=q&hl=zh-TW&geocode=&q=' + address + '&z=16&output=embed&t=" ></iframe > '
                        strElement += '</div>'


                        var elementStyle = {
                            position: 'relative',
                            display: 'inline-block'
                        };

                        //建立Dom元素
                        var element = CKEDITOR.dom.element.createFromHtml(strElement);
                            
                        element.setStyles(elementStyle)

                        var fakeElement = editor.createFakeElement(element, 'cke_iframe', 'iframe', true);

                        editor.insertElement(element);

                    },
                    onCancel: function () {
                        //alert('我取消囉');
                    }
                };


                return model;

            });
        },



    })

})();