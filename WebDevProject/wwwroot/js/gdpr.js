class GDPR {

    constructor() {
        this.showStatus();
        this.showContent();
        this.bindEvents();

        if (this.cookieStatus() !== 'accept') this.showGDPR();
    }

    bindEvents() {
        let buttonAccept = document.querySelector('.gdpr-consent__button--accept');
        buttonAccept.addEventListener('click', () => {
            this.cookieStatus('accept');
            this.showStatus();
            this.showContent();
            this.hideGDPR();
        });


        //student uitwerking
        let buttonReject = document.querySelector(".gdpr-consent__button--reject");
        buttonReject.addEventListener('click', () => {
            this.cookieStatus('reject');
            this.showStatus();
            this.showContent();
            this.hideGDPR();
        })
        //
    }


    showContent() {
        this.resetContent();
        const status = this.cookieStatus() == null ? 'not-chosen' : this.cookieStatus();
        const element = document.querySelector(`.content-gdpr-${status}`);
        if (element != null) {
            element.classList.add('show');
        }
    }

    resetContent() {
        const classes = [
            '.content-gdpr-accept',
            //student uitwerking
            '.content-gdpr-reject',
            //
            '.content-gdpr-not-chosen'];

        for (const c of classes) {
            let element = document.querySelector(c);
            if (element != null) {
                element.classList.remove('show');
                element.classList.add('hide');
            }
        }
    }

    showStatus() {
        //document.getElementById('content-gpdr-consent-status').innerHTML =
        //    this.cookieStatus() == null ? 'Niet gekozen' : this.cookieStatus();
    }

    cookieStatus(status) {
        if (status) {
            localStorage.setItem('gdpr-consent-choice', status);

            //student uitwerking
            let datum = { datum: new Date() };
            datum = JSON.stringify(datum);
            //JSON.parse('{"datum":"Date.now"}');
            localStorage.setItem('gdpr-consent-date', datum);
        }
        return localStorage.getItem('gdpr-consent-choice');
    }


    //student uitwerking


    hideGDPR() {
        document.querySelector(`.gdpr-consent`).classList.add('hide');
        document.querySelector(`.gdpr-consent`).classList.remove('show');
    }

    showGDPR() {
        document.querySelector(`.gdpr-consent`).classList.add('show');
        document.querySelector(`.gdpr-consent`).classList.remove('hide');
    }
}

const gdpr = new GDPR();

