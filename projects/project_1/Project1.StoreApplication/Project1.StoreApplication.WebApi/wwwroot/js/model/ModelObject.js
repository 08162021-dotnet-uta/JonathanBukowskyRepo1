
if (ModelObject === undefined) {
    var ModelObject = (function () {
        class ModelObject {
            _identifiers = [];

            /*
            constructor(data) {
                console.log("Base1", data);
                this.PopulateFromData(data);
                console.log("Base2", data);
            }
            */

            PopulateFromData(obj) {
                this._identifiers.forEach(prop => {
                    this[prop] = obj[prop];
                });
            }

            CreateElementFromTemplate(template) {
                let newElm = template.cloneNode(true);
                let templateClass = '';
                newElm.classList.forEach(className => {
                    if (className.includes('template')) {
                        templateClass = className;
                    }
                });
                if (!templateClass) {
                    throw new Error("Couldn't find template class");
                }
                this._identifiers.forEach(prop => {
                    let className = `${templateClass}-${prop}`;
                    let elms = Array.from(newElm.getElementsByClassName(className));
                    if (!elms.length) {
                        //console.log(`Elm for ${className} not found`);
                    }
                    elms.forEach(elm => {
                        //console.log(`Found Elm for ${className}`, elm);
                        elm.textContent = this[prop];
                        elm.classList.remove(className);
                    });
                });
                newElm.classList.remove(templateClass);
                let generatedClass = templateClass.replace("template", "generated");
                newElm.classList.add('generated');
                newElm.classList.add(generatedClass);
                return newElm;
            }
        }

        // If className provided, remove all elements from container with
        // className class. Otherwise, remove all generated elements
        function RemoveGeneratedElements(container, className='') {
            if (!className) {
                className = 'generated';
            }
            let elmsToRemove = Array.from(container.getElementsByClassName(className));
            elmsToRemove.forEach(elm => {
                container.removeChild(elm);
            });
        }

        // "export" list
        return {
            ModelObject,
            RemoveGeneratedElements
        }
    })();
}
